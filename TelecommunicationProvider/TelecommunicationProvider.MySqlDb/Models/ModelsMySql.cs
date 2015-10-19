// <copyright  file="ModelsMySql.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MySqlDb.Models
{
    using System;

    public class ModelsMySql
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ssn { get; set; }

        public string Type { get; set; }

        public int AddressId { get; set; }
    }
}
