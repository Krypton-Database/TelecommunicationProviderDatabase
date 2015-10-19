// <copyright  file="Startup.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Exporters;
    using TelecommunicationProvider.Data.Generators;
    using TelecommunicationProvider.Data.Importers;
    using TelecommunicationProvider.Data.Migrations;
    using TelecommunicationProvider.Models.SqlServerModels;
    using TelecommunicationProvider.MongoDb;

    public class Startup
    {
        private const string SampleContractsDataXmlFilePath = @"..\..\..\..\Data\Contracts-01-Oct-2015.xml";
        private const string SampleContractsDataExcelFolderPath = @"..\..\..\..\Data\Contracts\";
        private const string SampleContractsDataExcelFolderZipPathSource = @"..\..\..\..\Data\Contracts.zip";
        private const string SampleContractsDataExcelFolderZipPathTempDestination = @"..\..\..\..\Data\UnZipContracts\";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TelecommunicationDbContext, Configuration>());

            var db = new TelecommunicationDbContext();
            var databaseMongoDbContext = new TelecommunicationProviderMongoDbContext();
            Console.WriteLine(db.Adresses.Count());

            ImportContractsFromXml(db, SampleContractsDataXmlFilePath);
           ImportContractsFromExcelFilesInFolder(db, SampleContractsDataExcelFolderPath);
           //ImportDataFromMongo(db, databaseMongoDbContext);
            ImportDataFromZipedExcel(db, SampleContractsDataExcelFolderZipPathSource);

           // ExportReportsToXml(db);

            var pdfReport = new PdfReportGenerator();
            pdfReport.CreateUserReport(db.Users);
        }

        private static void ImportContractsFromXml(TelecommunicationDbContext telecommunicationDbContext, string xmlDataPath)
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

        private static void ImportContractsFromExcelFilesInFolder(TelecommunicationDbContext telecommunicationDbContext, string excelFolderDataPath)
        {
            ExcelImporter excelDataImporter = new ExcelImporter();
            ICollection<Contract> importedContractsFromExcel =
            excelDataImporter.ImportContractsDataFromDirectory(excelFolderDataPath);
            foreach (var contract in importedContractsFromExcel)
            {
                telecommunicationDbContext.Contracts.Add(contract);
            }

            telecommunicationDbContext.SaveChanges();
        }

        private static void ImportDataFromMongo(TelecommunicationDbContext telecommunicationDbContext, ITelecommunicationProviderMongoDbContext telecommunicationMongoDbContext)
        {
            var mongoData = new TelecommunicationProviderMongoDb(telecommunicationMongoDbContext);

            var usersCollection = mongoData.User.FindAll();

            var telephonesCollection = mongoData.TelephoneNumber.FindAll();

            var addressCollection = mongoData.Address.FindAll();

            foreach (var item in usersCollection)
            {
                var user = new User
                               {
                                   FirstName = item.FirstName,
                                   LastName = item.LastName,
                                   Ssn = item.Ssn,
                                   Type = item.Type,
                                   AddressId = item.AddressId
                               };
                telecommunicationDbContext.Users.Add(user);
                telecommunicationDbContext.SaveChanges();
            }

            foreach (var item in telephonesCollection)
            {
                var phone = new TelephoneNumber
                {
                    Number = item.Number,
                    UserId = item.UserId
                };
                telecommunicationDbContext.TelephoneNumbers.Add(phone);
                telecommunicationDbContext.SaveChanges();
            }

            foreach (var item in addressCollection)
            {
                var address = new Address
                {
                    Name = item.Name,
                    Number = item.Number,
                    City = item.City,
                    Country = item.Country,
                    ZipCode = item.ZipCode
                };
                telecommunicationDbContext.Adresses.Add(address);
                telecommunicationDbContext.SaveChanges();
            }
        }

        private static void ImportDataFromZipedExcel(TelecommunicationDbContext telecommunicationDbContext, string sourcePath, string destinationPath = SampleContractsDataExcelFolderZipPathTempDestination)
        {
            ZipExtractor zipExtractor = new ZipExtractor();

            zipExtractor.Extract(sourcePath, destinationPath);

            ImportContractsFromExcelFilesInFolder(telecommunicationDbContext, destinationPath);
        }

        private static void ExportReportsToXml(TelecommunicationDbContext telecommunicationDbContext)
        {
            XmlExporter exp = new XmlExporter();
            exp.GenerateXmlReport(telecommunicationDbContext);
        }
    }
}