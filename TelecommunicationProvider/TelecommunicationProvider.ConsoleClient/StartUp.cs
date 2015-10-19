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

    using TelecommunicationProvider.ConsoleClient.DataManipulators;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Exporters;
    using TelecommunicationProvider.Data.Generators;
    using TelecommunicationProvider.Data.Importers;
    using TelecommunicationProvider.Data.Migrations;
    using TelecommunicationProvider.Models.SqlServerModels;
    using TelecommunicationProvider.MongoDb;

    public class Startup
    {
        private const string SampleContractsDataXmlFilePath = @"..\..\..\..\InputData\Contracts-01-Oct-2015.xml";
        private const string SampleContractsDataExcelFolderPath = @"..\..\..\..\InputData\Contracts\";
        private const string SampleContractsDataExcelFolderZipPathSource = @"..\..\..\..\InputData\Contracts.zip";
        private const string PdfDataFolderPath = @"..\..\..\..\OutputData\Pdf";
        private const string PdfDataFileName = @"UsersReport.pdf";


        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TelecommunicationDbContext, Configuration>());
            var db = new TelecommunicationDbContext();
            var databaseMongoDbContext = new TelecommunicationProviderMongoDbContext();

            var excelManipulator = new ExcelManipulator();
            var xmlManipulator = new XmlManipulator();
            var mongoManipulator = new MongoManipulator();
            var pdfManipulator = new PdfManipulator();
            var address = new Address
                              {
                                  Name = "lalalla",
                                  Number = 23,
                                  City = "Sofiq",
                                  Country = "Bulgaria",
                                  ZipCode = "1000"
                              };
            db.Adresses.Add(address);
            db.SaveChanges();

            //Run the program for first time with those methods commented, for initializing and adding some data in the database
            //Run the program for second time with those method uncommented(xmlManipulator.ExportReportsToXml(db)->with this method commented(it is not working yet)))


            xmlManipulator.ImportContractsFromXml(db, SampleContractsDataXmlFilePath);
            excelManipulator.ImportContractsFromExcelFilesInFolder(db, SampleContractsDataExcelFolderPath);
            //mongoManipulator.ImportDataFromMongo(db, databaseMongoDbContext);
            excelManipulator.ImportDataFromZipedExcel(db, SampleContractsDataExcelFolderZipPathSource);
            //xmlManipulator.ExportReportsToXml(db);
            pdfManipulator.CreatePdfReport(db, PdfDataFolderPath, PdfDataFileName);


        }
    }
}