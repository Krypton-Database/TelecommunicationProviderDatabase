namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Generators;

    public class PdfManipulator
    {
        public void CreatePdfReport(TelecommunicationDbContext telecommunicationDbContext, string fileName)
        {
            var pdfReport = new PdfReportGenerator();
            pdfReport.CreateUserReport(telecommunicationDbContext.Users, fileName);
        }
    }
}
