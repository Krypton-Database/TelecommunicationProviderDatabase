namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using System.Collections.Generic;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Importers;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class ExcelManipulator
    {
        private const string SampleContractsDataExcelFolderZipPathTempDestination = @"..\..\..\..\Data\UnZipContracts\";

        public void ImportContractsFromExcelFilesInFolder(TelecommunicationDbContext telecommunicationDbContext, string excelFolderDataPath)
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

       public void ImportDataFromZipedExcel(TelecommunicationDbContext telecommunicationDbContext, string sourcePath, string destinationPath = SampleContractsDataExcelFolderZipPathTempDestination)
        {
            ZipExtractor zipExtractor = new ZipExtractor();

            zipExtractor.Extract(sourcePath, destinationPath);

            this.ImportContractsFromExcelFilesInFolder(telecommunicationDbContext, destinationPath);
        }
    }
}
