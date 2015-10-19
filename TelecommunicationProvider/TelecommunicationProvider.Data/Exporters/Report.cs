namespace TelecommunicationProvider.Data.Exporters
{
    using System;
    internal class Report
    {
        internal Report(DateTime date, string name, decimal? sum)
        {
            this.ReportDate = date;
            this.PackName = name;
            this.Sum = sum;
        }

        internal DateTime ReportDate { get; set; }

        internal string PackName { get; set; }

        internal decimal? Sum { get; set; }
    }
}
