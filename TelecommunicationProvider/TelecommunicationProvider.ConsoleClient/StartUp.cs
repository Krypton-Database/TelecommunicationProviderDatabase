namespace TelecommunicationProvider.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Importers;
    using TelecommunicationProvider.Data.Migrations;
    using TelecommunicationProvider.Models;

    public class Startup
    {
        private const string SampleContractsDataXmlFilePath = @"..\..\..\..\Data\Contracts-01-Oct-2015.xml";
        private const string SampleContractsDataExcelFilePath = @"..\..\..\..\Data\Contracts\Contracts-17-Oct-2015.xls";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TelecommunicationDbContext, Configuration>());

            var db = new TelecommunicationDbContext();
            Console.WriteLine(db.Adresses.Count());

            ImportContractsFromXml(db);
            ImportContractsFromExcel(db);
        }

        private static void ImportContractsFromXml(TelecommunicationDbContext telecommunicationDbContext)
        {
            XmlImporter xmlDataImporter = new XmlImporter();
            ICollection<Contract> importedContractsFromXml =
            xmlDataImporter.ImportContractsDataFromFile(SampleContractsDataXmlFilePath);
            foreach (var contract in importedContractsFromXml)
            {
                telecommunicationDbContext.Contracts.Add(contract);
                telecommunicationDbContext.SaveChanges();
            }

            telecommunicationDbContext.SaveChanges();
        }

        private static void ImportContractsFromExcel(TelecommunicationDbContext telecommunicationDbContext)
        {
            ExcelImporter excelDataImporter = new ExcelImporter();
            ICollection<Contract> importedContractsFromExcel =
            excelDataImporter.ImportContractsDataFromFile(SampleContractsDataExcelFilePath);
            foreach (var contract in importedContractsFromExcel)
            {
                telecommunicationDbContext.Contracts.Add(contract);
            }

            telecommunicationDbContext.SaveChanges();
        }
    }
}
