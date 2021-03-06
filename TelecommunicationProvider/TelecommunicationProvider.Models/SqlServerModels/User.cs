﻿// <copyright  file="User.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System.Collections.Generic;

    public class User
    {
        private ICollection<TelephoneNumber> telephoneNumber;

        public User()
        {
            this.telephoneNumber = new HashSet<TelephoneNumber>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ssn { get; set; }

        public string Type { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<TelephoneNumber> TelephoneNumbers
        {
            get { return this.telephoneNumber; }
            set { this.telephoneNumber = value; }
        }
    }
}