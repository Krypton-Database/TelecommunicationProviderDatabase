// <copyright  file="Report.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Exporters
{
    using System;

    internal class Report
    {
        internal Report(int year, string name, decimal? sum)
        {
            this.ReportYear = year;
            this.PackName = name;
            this.Sum = sum;
        }

        internal int ReportYear { get; set; }

        internal string PackName { get; set; }

        internal decimal? Sum { get; set; }
    }
}
