namespace TelecommunicationProvider.Data.Exporters
{
    using SpreadsheetLight;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelecommunicationProvider.MySqlDb;
    using TelecommunicationProvider.Sqlite;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Spreadsheet;

    public class ExcelExporter
    {
        private const string OutputPath = "../../../../OutputData/Excel/Reports/";
        private const string OutputFileNameFormat = "{0}TelecommunicationReport{1}.xlsx";

        public void GenerateCompositeTelecommunicationReport()
        {
            Console.WriteLine("Generating merged report from SQLite and MySql...");

            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            SLDocument excelFile = new SLDocument();

            using (var sqliteDbContext = new TelecommunicationProviderDbContext())
            {
                var mysqlDbContext = new TelecommunicationProviderMySqlData();

                var compositeReports = from MySqlData in mysqlDbContext.ModelsMySqlRepository.All().AsEnumerable()
                                       join sqliteData in sqliteDbContext.DifferentUserProviders.AsEnumerable()
                                       on 1 equals 1 // it's magic :D 
                                       select
                                       new
                                       {
                                           // MySqlData.Id,
                                           MySqlData.NumberOfContracts,
                                           MySqlData.Date,
                                           // sqliteData.Id,
                                           sqliteData.NumberOfProviders,
                                           sqliteData.UserSsn
                                       };

                excelFile.SetCellValue("A1", "User SSN");
                excelFile.SetCellValue("B1", "Number of Contracts");
                excelFile.SetCellValue("C1", "Number of Providers");
                excelFile.SetCellValue("D1", "Date");
                //excelFile.SetCellValue("E1", "From Date");
                //excelFile.SetCellValue("F1", "To Date");
                //excelFile.SetCellValue("G1", "Company Website");
                //excelFile.SetCellValue("H1", "Foundation Year");

                int rowCounter = 2;
                foreach (var report in compositeReports)
                {
                    excelFile.SetCellValue("A" + rowCounter, report.UserSsn);
                    excelFile.SetCellValue("B" + rowCounter, report.NumberOfContracts.ToString());
                    excelFile.SetCellValue("C" + rowCounter, report.NumberOfProviders.ToString());
                    excelFile.SetCellValue("D" + rowCounter, report.Date.ToString());
                    //excelFile.SetCellValue("E" + rowCounter, report.StartDate.ToString());
                    //excelFile.SetCellValue("F" + rowCounter, report.EndDate.ToString());
                    //excelFile.SetCellValue("G" + rowCounter, report.Website.ToString());
                    //excelFile.SetCellValue("H" + rowCounter, report.FoundationYear.ToString());
                    rowCounter++;

                }
            }

            DateTime currentDate = DateTime.Now;
            string fileNameSuffix = string.Format("-{0}.{1}.{2}-{3}.{4}.{5}",
                currentDate.Day, currentDate.Month, currentDate.Year, currentDate.Hour, currentDate.Minute, currentDate.Second);

            excelFile.SaveAs(string.Format(OutputFileNameFormat, OutputPath, fileNameSuffix));
        }
    }
}
