namespace TelecommunicationProvider.Data.Exporters
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class CorrectXmlReport
    {
        public void GenerateXmlReport(string filePath, TelecommunicationDbContext db)
        {
            var contracts = db.Contracts.ToList();
            var grouped = contracts.GroupBy(x => x.StartDate.Date);

            var element = new XElement("contracts");
            var doc = new XDocument(element);
            foreach (var item in grouped)
            {
                element.Add(new XElement("info-contact", new XElement("Date", item.Key.Date), new XElement("Num-of-contracts", item.Count())));
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fileName = "XMLReport.xml";
            var fullPath = filePath + fileName;
            doc.Save(fullPath);
            Console.WriteLine("XML file is ready!");
        }
    }
}
