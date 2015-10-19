// <copyright  file="ModelsMySql.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MySqlDb.Models
{
    using System;

    public class MonthlyNumberOfContracts
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfContracts { get; set; }
    }
}
