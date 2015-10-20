// <copyright  file="PdfReportGenerator.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Generators
{
    using System;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class PdfReportGenerator
    {
        private string workingDir = @"..\..\..\..\OutputData\Pdf";

        public PdfReportGenerator()
        {
            if (!Directory.Exists(workingDir))
            {
                Directory.CreateDirectory(workingDir);
            }
        }

        public void CreateUserReport(IQueryable<Contract> contract, string fileName, DateTime date)
        {
            using (var fs = new FileStream(Path.Combine(workingDir, fileName), FileMode.Create, FileAccess.Write))
            {
                Console.WriteLine("Generating of UsersReport.pdf initialized.");

                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter.GetInstance(document, fs);
                document.Open();

                int year = date.Year;
                int month = date.Month;
                int day = date.Day;

                var groups = contract.Select(x => new
                {
                    FirstName = x.TelephoneNumber.User.FirstName,
                    LastName = x.TelephoneNumber.User.LastName,
                    City = x.TelephoneNumber.User.Address.City,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                }).GroupBy(y => y.City).ToList();

                var contractsAll = groups;
                var contrCount = contractsAll.Count;
                var userCount = 0;

                document.Add(new Paragraph(new Phrase("\n" + "Report for Date: " + year.ToString() + "-" + month.ToString() + "-" + day.ToString())));
                document.Add(new Paragraph(new Phrase("\n")));

                for (int i = 0; i < contrCount; i++)
                {
                    var singleContract = contractsAll[i];

                    var table = new PdfPTable(5);

                    var headerCell = new PdfPCell(new Phrase("City: " + singleContract.Key));
                    headerCell.Colspan = 5;
                    headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                    headerCell.HorizontalAlignment = 1;
                    table.AddCell(headerCell);

                    table.AddCell("First Name");
                    table.AddCell("Last Name");
                    table.AddCell("City");
                    table.AddCell("Start Date");
                    table.AddCell("End Date");

                    foreach (var contr in singleContract)
                    {
                        if (contr.StartDate.Year == year && contr.StartDate.Month == month && contr.StartDate.Day == day)
                        {
                            table.AddCell(contr.FirstName);
                            table.AddCell(contr.LastName);
                            table.AddCell(contr.City);
                            table.AddCell(contr.StartDate.Year.ToString() + "-" + contr.StartDate.Month.ToString() + "-" + contr.StartDate.Day.ToString());
                            table.AddCell(contr.EndDate.Year.ToString() + "-" + contr.EndDate.Month.ToString() + "-" + contr.EndDate.Day.ToString());
                            userCount = userCount + 1;
                        }
                    }

                    document.Add(table);
                    document.Add(new Paragraph(new Phrase("\n")));
                }

                document.Add(new Paragraph(new Phrase("\n" + "Total User count: " + userCount)));

                var footer = new Paragraph(new Phrase("User Report"));
                footer.Alignment = 1;

                document.Add(footer);
                document.Close();

                Console.WriteLine("Generating of pdf report completed!");
            }
        }
    }
}
