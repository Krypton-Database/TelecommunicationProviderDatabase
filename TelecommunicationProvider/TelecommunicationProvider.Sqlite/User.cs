namespace TelecommunicationProvider.Sqlite
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserPhoneInfo")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string PhoneManufacturer { get; set; }

        public string PhoneModel { get; set; }
    }
}
