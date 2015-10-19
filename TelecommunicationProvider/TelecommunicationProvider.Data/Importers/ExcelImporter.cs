// <copyright  file="ExcelImporter.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class ExcelImporter
    {
        private const string WorksheetFileExtensionPattern = @".xls[x]?\b";
        private const string ContractsWorksheetFilePattern = @"\Contracts-\d{2}-\w{3}-\d{4}.xls[x]?\b";
        private const string InvalidFileNameMessage = @"Provided file name is either invalid or does not match
                                                    the naming convention for an xls/xlsx [{0}] data file.";

        public ICollection<Contract> ImportContractsDataFromDirectory(string directoryPath)
        {
            IEnumerable<string> filePaths = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            //// .Where(p => Regex.IsMatch(p, ContractsWorksheetFilePattern));

            ICollection<Contract> importedContracts = new HashSet<Contract>();

            foreach (var path in filePaths)
            {
                foreach (var contract in this.ImportContractsDataFromFile(path))
                {
                    importedContracts.Add(contract);
                }
            }

            return importedContracts;
        }

        public ICollection<Contract> ImportContractsDataFromFile(string filePath)
        {
            Console.WriteLine("Importing data from excel files");
            //// if (!Regex.IsMatch(filePath, ContractsWorksheetFilePattern))
            //// {
            ////    throw new ArgumentException(string.Format(InvalidFileNameMessage, "Contracts"));
            //// }

            OleDbConnection connection = new OleDbConnection();

            string connectionString =
                ConfigurationManager.ConnectionStrings["TelecommunicationProviderExcelData"].ConnectionString;
            connection.ConnectionString = string.Format(connectionString, filePath);

            connection.Open();

            using (connection)
            {
                var schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = schema.Rows[0]["TABLE_NAME"].ToString();

                OleDbCommand selectAllRowsCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);

                ICollection<Contract> importedContracts = new HashSet<Contract>();

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectAllRowsCommand))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    using (DataTableReader reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                DateTime startDate = DateTime.Parse(reader["StartDate"].ToString());
                                DateTime endDate = DateTime.Parse(reader["EndDate"].ToString());
                                int packageId = int.Parse(reader["PackageID"].ToString());
                                int telephoneId = int.Parse(reader["TelephoneID"].ToString());

                                var contract = new Contract
                                                   {
                                                       StartDate = startDate,
                                                       EndDate = endDate,
                                                       PackageId = packageId,
                                                       TelephoneNumberId = telephoneId
                                                   };

                                importedContracts.Add(contract);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                Console.WriteLine("Importing data from excel completed!");
                return importedContracts;
            }
        }
    }
}