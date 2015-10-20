// <copyright  file="XmlImporter.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class XmlImporter
    {
        //// private const string XmlFileExtensionPattern = @".xml\b";

        //// private const string ContractsXmlFilePattern = @"*+\Contracts-\d{2}-\w{3}-\d{4}.xml\b";

       //// private const string InvalidFileNameMessage = "Provided file name is invalid";

        public ICollection<Contract> ImportContractsDataFromFile(string filePath)
        {
            Console.WriteLine("Importing data from xml file");
            //// if (!Regex.IsMatch(filePath, ContractsXmlFilePattern))
            //// {
            ////     throw new ArgumentException(string.Format(InvalidFileNameMessage));
            //// }

            ICollection<Contract> importedContracts = new HashSet<Contract>();

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                while (reader.Read())
                {
                    try
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "contract")
                        {
                            int contractId = int.Parse(reader.GetAttribute("id"));
                            DateTime contractStartDate = DateTime.Parse(reader.GetAttribute("StartDateTime"));
                            DateTime contractsEndDate = DateTime.Parse(reader.GetAttribute("EndDateTime"));

                            reader.ReadToDescendant("telephoneNumber");
                            int telephoneNumberId = int.Parse(reader.GetAttribute("telephoneNumberId"));

                            reader.ReadToNextSibling("package");
                            int packageId = int.Parse(reader.GetAttribute("packageId"));

                            var contract = new Contract()
                            {
                                StartDate = contractStartDate,
                                EndDate = contractsEndDate,
                                TelephoneNumberId = telephoneNumberId,
                                PackageId = packageId
                            };

                            importedContracts.Add(contract);
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("Importing data from xml file completed!");
            return importedContracts;
        }
    }
}