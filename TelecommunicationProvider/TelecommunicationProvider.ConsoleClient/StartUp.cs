﻿// <copyright  file="Startup.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TelecommunicationProvider.ConsoleClient.DataManipulators;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Exporters;
    using TelecommunicationProvider.Data.Generators;
    using TelecommunicationProvider.Data.Migrations;
    using TelecommunicationProvider.Models.SqlServerModels;
    using TelecommunicationProvider.MongoDb;

    public class Startup
    {
        private const string SampleContractsDataXmlFilePath = @"..\..\..\..\InputData\Contracts-01-Oct-2015.xml";

        private const string SampleContractsDataExcelFolderPath = @"..\..\..\..\InputData\Contracts\";

        private const string SampleContractsDataExcelFolderZipPathSource = @"..\..\..\..\InputData\Contracts.zip";

        //// private const string PdfDataFolderPath = @"..\..\..\..\OutputData\Pdf";
        
        private const string PdfDataFileNameContract = @"ContractReport.pdf";

        private const string PdfDataFileNameUsers = @"UsersReport.pdf";

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
            Console.WriteLine("command /create database/ to create database");
            Console.WriteLine("command /xml import/ to import contracts from xml");
            Console.WriteLine("command /excel import/ to import contracts from excel");
            Console.WriteLine("command /mongo import/ to import users, addresses and packages from mongo");
            Console.WriteLine("command /zipped excel files/ to import contracts from excel ");
            Console.WriteLine("command /xml export/ to export xml reports");
            Console.WriteLine("command /create pdf contract/ to export pdf report for contracts for a date");
            Console.WriteLine("command /create pdf user/ to export pdf reports for all users");
            Console.WriteLine("command /export json/ to export pdf reports");
            Console.WriteLine("command /import mysql/ to export pdf reports");
            Console.WriteLine("command /export excel/ to export excel reports");
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "exit")
            {
                switch (command)
                {
                    case "create database":
                        {
                            var dataBase = new DataBaseCreator();
                            dataBase.CreateDatabase(db);
                            Console.WriteLine("Database created");
                            break;
                        }

                    case "xml import":
                        {
                            xmlManipulator.ImportContractsFromXml(db, SampleContractsDataXmlFilePath);
                            break;
                        }

                    case "excel import":
                        {
                            excelManipulator.ImportContractsFromExcelFilesInFolder(
                                db,
                                SampleContractsDataExcelFolderPath);
                            break;
                        }

                    case "mongo import":
                        {
                            mongoManipulator.ImportDataFromMongo(db, databaseMongoDbContext);
                            break;
                        }

                    case "zipped excel files":
                        {
                            excelManipulator.ImportDataFromZipedExcel(db, SampleContractsDataExcelFolderZipPathSource);
                            break;
                        }

                    case "xml export":
                        {
                            var xml = new XmlManipulator();
                            xml.ExportReportsToXml(db, @"../../../../OutputData/XML/Reports/");
                            break;
                        }

                    case "create pdf contract":
                        {
                            Console.Write("Please enter for which date you need the report (mm/dd/year): ");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            pdfManipulator.CreatePdfContractReport(db, PdfDataFileNameContract, date);
                            break;
                        }

                    case "create pdf user":
                        {
                            pdfManipulator.CreatePdfUserReport(db, PdfDataFileNameUsers);
                            break;
                        }

                    case "export json":
                        {
                            var json = new JsonReportGenerator();
                            var listOfContracts = db.Contracts.ToList();
                            json.ExportContracts(listOfContracts, @"..\..\..\..\OutputData\JsonReports");
                            break;
                        }

                    case "import mysql":
                        {
                            var sqlManipulator = new MySqlManipulator();
                            sqlManipulator.ImportDataToMySql(db.Contracts.ToList());
                            break;
                        }

                    case "export excel":
                        {
                            ComposeDataFromSQLiteAndMySqlAndExportToExcel();
                            break;
                        }

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }

        private static void ComposeDataFromSQLiteAndMySqlAndExportToExcel()
        {
            ExcelExporter excelExporter = new ExcelExporter();
            excelExporter.GenerateCompositeTelecommunicationReport();
        }
    }
}