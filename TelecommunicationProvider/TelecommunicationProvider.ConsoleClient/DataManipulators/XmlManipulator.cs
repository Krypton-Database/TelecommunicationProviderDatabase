namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using System.Collections.Generic;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Exporters;
    using TelecommunicationProvider.Data.Importers;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class XmlManipulator
    {
        public void ImportContractsFromXml(TelecommunicationDbContext telecommunicationDbContext, string xmlDataPath)
        {
            XmlImporter xmlDataImporter = new XmlImporter();
            ICollection<Contract> importedContractsFromXml =
            xmlDataImporter.ImportContractsDataFromFile(xmlDataPath);
            foreach (var contract in importedContractsFromXml)
            {
                telecommunicationDbContext.Contracts.Add(contract);
            }

            telecommunicationDbContext.SaveChanges();
        }

        public void ExportReportsToXml(TelecommunicationDbContext telecommunicationDbContext, string filePath)
        {
            CorrectXmlReport exp = new CorrectXmlReport();
            exp.GenerateXmlReport(filePath, telecommunicationDbContext);
        }
    }
}
