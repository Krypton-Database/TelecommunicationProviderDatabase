// <copyright  file="XmlExporter.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Exporters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class XmlExporter
    {
        private const string OutputPath = "../../../../OutputData/XML/Reports/";
        private const string OutputFileName = "XMLReport.xml";
        private const int YearOfFirstReport = 2011;
        private const int YearOfSecondReport = 2012;
        private const int YearOfThirdReport = 2013;
        private const int YearOfFourthReport = 2014;
        private const int YearOfFifthReport = 2015;


        public void GenerateXmlReport(TelecommunicationDbContext db)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            bool exists = System.IO.Directory.Exists(OutputPath);

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(OutputPath);
            }

            using (XmlTextWriter writer = new XmlTextWriter(OutputPath + OutputFileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                var packages = db.Packages.ToList();

                var summaryFromThеFirstYear = this.GetDataFromDB(packages, YearOfFirstReport);
                var summaryFromTheSecondYear = this.GetDataFromDB(packages, YearOfSecondReport);
                var summaryFromTheThirdYear = this.GetDataFromDB(packages, YearOfThirdReport);
                var summaryFromFourthYear = this.GetDataFromDB(packages, YearOfFourthReport);
                var summaryFromFifthYear = this.GetDataFromDB(packages, YearOfFifthReport);

                var summariesAll = summaryFromThеFirstYear
                    .Concat(summaryFromTheSecondYear)
                    .Concat(summaryFromTheThirdYear)
                    .Concat(summaryFromFourthYear)
                    .Concat(summaryFromFifthYear)
                    .ToList()
                    .GroupBy(s => s.PackName);

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (var summaryPack in summariesAll)
                {
                    writer.WriteStartElement("sale");

                    writer.WriteAttributeString("name", summaryPack.Key);

                    foreach (var summary in summaryPack)
                    {
                        int reportDate = summary.ReportYear;
                        var sum = summary.Sum;
                        CreateSummary(writer, reportDate, sum);
                    }

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                Console.WriteLine("XML file is ready!");
            }
        }

        private static void CreateSummary(XmlWriter writer, int date, decimal? sum)
        {
            writer.WriteStartElement("summary");
            writer.WriteAttributeString("year", date.ToString());
            writer.WriteAttributeString("total-sum", sum.ToString());
            writer.WriteEndElement();
        }

        private IList<Report> GetDataFromDB(IList<Package> packages, int year)
        {
            IList<Report> summeries = new List<Report>();

            decimal? annualIncome;

            foreach (Package package in packages)
            {
                annualIncome = AnnualIncome(year, package.Contracts, package);
                summeries.Add(
                    new Report(year, package.Name, annualIncome));
            }

            return summeries;
        }

        private int CheckActualContracts(ICollection<Contract> contracts, DateTime reportDate)
        {
            int result = contracts.Select(c => c.EndDate < reportDate).ToList().Count();
            return result;
        }

        private decimal? AnnualIncome(int year, ICollection<Contract> contracts, Package package)
        {
            decimal? annualIncome = 0;

            int activeContracts;

            for(var i = 1; i <= 12; i++)
            {
                if(i == 1)
                {
                    activeContracts = CheckActualContracts(contracts, new DateTime(year, i, 01));
                }
                else if (i == 12)
                {
                    activeContracts = CheckActualContracts(contracts, new DateTime(year, i, 31));
                }
                else
                {
                    activeContracts = CheckActualContracts(contracts, new DateTime(year, i, 28));
                }
                annualIncome += activeContracts * package.Price;
            }

            return annualIncome;
        }
    }
}
