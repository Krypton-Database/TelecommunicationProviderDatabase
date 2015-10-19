﻿namespace TelecommunicationProvider.Data.Exporters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;  
    using System.Xml;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class XMLExporter
    {
        private const string OutputPath = "/../../../Reports/XMLReport.xml";

        public void GenerateXMLReport(TelecommunicationDbContext db)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(OutputPath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                var now = DateTime.Now;
                var summaryFromThisYear = this.GetDataFromDB(db, now);
                var summaryFromBeforeFiveYears = this.GetDataFromDB(db, new DateTime(now.Year - 5, 01, 01));
                var summaryFromBeforeEightYears = this.GetDataFromDB(db, new DateTime(now.Year - 8, 01, 01));

                var summariesAll = summaryFromThisYear.Concat(summaryFromBeforeFiveYears).Concat(summaryFromBeforeEightYears).ToList().GroupBy(s => s.PackName);

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (Report summary in summariesAll)
                {
                    DateTime reportDate = summary.ReportDate;
                    var packageName = summary.PackName;
                    var sum = summary.Sum;
                    CreateSummary(writer, reportDate, packageName, sum);
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
                Console.WriteLine("XML file is ready!");
            }
        }

        private static void CreateSummary(XmlWriter writer, DateTime date, string name, decimal? sum)
        {
            writer.WriteStartElement("summary");
            writer.WriteStartAttribute("date", date.ToString());
            writer.WriteStartAttribute("total-sum", sum.ToString());
            writer.WriteEndElement();
        }

        private IList<Report> GetDataFromDB(TelecommunicationDbContext db, DateTime reportDate)
        {
            var packages = db.Packages.ToList();

            IList<Report> summeries = new List<Report>();

            int activeContracts;

            foreach (Package package in packages)
            {
                activeContracts = this.CheckActualContracts(package.Contracts, reportDate);
                summeries.Add(
                    new Report(reportDate, package.Name, activeContracts * package.Price));
            }

            return summeries;
        }

        private int CheckActualContracts(ICollection<Contract> contracts, DateTime reportDate)
        {
            int result = contracts.Select(c => c.EndDate < reportDate).ToList().Count();
            return result;
        }
    }
}
