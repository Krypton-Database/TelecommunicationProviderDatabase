namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using System;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Generators;

    public class PdfManipulator
    {
        public void CreatePdfReport(TelecommunicationDbContext telecommunicationDbContext, string fileName, DateTime date)
        {
            var pdfReport = new PdfReportGenerator();
            pdfReport.CreateUserReport(telecommunicationDbContext.Contracts, fileName, date);
        }
    }
}
