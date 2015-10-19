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
        private readonly string workingDir = ".../.../Reports/Pdf";

        public PdfReportGenerator()
        {
            if (!Directory.Exists(this.workingDir))
            {
                Directory.CreateDirectory(this.workingDir);
            }
        }

        public void CreateUserReport(IQueryable<User> usersdata)
        {
            using (var fs = new FileStream(Path.Combine(this.workingDir, "UsersReport.pdf"), FileMode.Create, FileAccess.Write))
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
                .GroupBy(x => x.FirstName)
                .ToList();

                var users = groups;

                for (int i = 0; i < users.Count; i++)
                {
                    var singleUser = users[i];

                    var table = new PdfPTable(6);

                    var headerCell = new PdfPCell(new Phrase("User N: " + singleUser.Key));
                    headerCell.Colspan = 6;
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

                var footer = new Paragraph(new Phrase("User Report"));
                footer.Alignment = 1;

                document.Add(footer);
                document.Close();

                Console.WriteLine("Generating of pdf report completed!");
            }
        }
    }
}
