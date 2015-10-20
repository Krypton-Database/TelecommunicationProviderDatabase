namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using System;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Generators;

    public class PdfManipulator
    {
        public void CreatePdfContractReport(TelecommunicationDbContext telecommunicationDbContext, string fileName, DateTime date)
        {
            var pdfReport = new PdfReportGenerator();
            pdfReport.CreateContractReport(telecommunicationDbContext.Contracts, fileName, date);
        }

        public void CreatePdfUserReport(TelecommunicationDbContext telecommunicationDbContext, string fileName)
        {
            var pdfReport = new PdfReportGenerator();
            pdfReport.CreateUserReport(telecommunicationDbContext.Users, fileName);
        }
    }
}
