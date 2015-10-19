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

        public void CreateUserReport(IQueryable<User> usersdata, string fileName)
        {
            using (var fs = new FileStream(Path.Combine(workingDir, fileName), FileMode.Create, FileAccess.Write))
            {
                Console.WriteLine("Generating of UsersReport.pdf initialized.");

                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter.GetInstance(document, fs);
                document.Open();


                var groups = usersdata.Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Address = a.Address,
                })
                .GroupBy(x => x.Address.City)
                .ToList();

                var users = groups;
                var userCount = users.Count;

                for (int i = 0; i < userCount; i++)
                {
                    var singleUser = users[i];

                    var table = new PdfPTable(5);

                    var headerCell = new PdfPCell(new Phrase("City: " + singleUser.Key));
                    headerCell.Colspan = 5;
                    headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                    headerCell.HorizontalAlignment = 1;
                    table.AddCell(headerCell);

                    table.AddCell("First Name");
                    table.AddCell("Last Name");
                    table.AddCell("City");
                    table.AddCell("Country");
                    table.AddCell("Zip Code");

                    foreach (var user in singleUser)
                    {
                        table.AddCell(user.FirstName);
                        table.AddCell(user.LastName);
                        table.AddCell(user.Address.City);
                        table.AddCell(user.Address.Country);
                        table.AddCell(user.Address.ZipCode);
                    }

                    document.Add(table);
                    document.Add(new Paragraph(new Phrase("\n")));
                }

                document.Add(new Paragraph(new Phrase("\n" + "Total User count: " + usersdata.Count())));

                var footer = new Paragraph(new Phrase("User Report"));
                footer.Alignment = 1;

                document.Add(footer);
                document.Close();

                Console.WriteLine("Generating of pdf report completed!");
            }
        }
    }
}
