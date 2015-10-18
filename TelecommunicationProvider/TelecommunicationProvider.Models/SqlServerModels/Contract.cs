namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System;

    public class Contract
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TelephoneNumberId { get; set; }

        public virtual TelephoneNumber TelephoneNumber { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}