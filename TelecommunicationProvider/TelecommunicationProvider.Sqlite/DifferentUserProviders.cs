namespace TelecommunicationProvider.Sqlite
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NumUserProviders")]
    public class DifferentUserProviders
    {
        public string UserSsn { get; set; }

        [Key]
        public int Id { get; set; }

        public int NumberOfProviders { get; set; }
    }
}
