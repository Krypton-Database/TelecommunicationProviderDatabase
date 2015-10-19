// <copyright  file="ModelConfiguration.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MySqlDb
{
    using System.Collections.Generic;
    using Models;
    using Telerik.OpenAccess.Metadata.Fluent;

    /// <summary>
    /// Model for MySQL
    /// </summary>
    public class ModelConfiguration : FluentMetadataSource
    {
        /// <summary>
        /// prepare for mapping
        /// </summary>
        /// <returns>configuration to map</returns>
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var mySqlMapping = new MappingConfiguration<ModelsMySql>();

            mySqlMapping.MapType(report => new
            {
                Id = report.Id,
                FirstName = report.FirstName,
                LastName = report.LastName,
                Ssn = report.Ssn,
                AddressId = report.AddressId,
                Type = report.Type,
            }).ToTable("MySql");

            mySqlMapping.HasProperty(c => c.Id).IsIdentity();

            configurations.Add(mySqlMapping);

            return configurations;
        }
    }
}