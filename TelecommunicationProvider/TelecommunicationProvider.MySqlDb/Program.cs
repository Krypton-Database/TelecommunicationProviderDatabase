namespace TelecommunicationProvider.MySqlDb
{
    using System;
    using TelecommunicationProvider.MySqlDb.Models;

    public static class Program
    {
        public static void Main()
        {
            var db = new TelecommunicationProviderMySqlData();
            db.ModelsMySqlRepository.Add(new MonthlyNumberOfContracts
                                             {
                                                 Date = new DateTime(2015, 05, 05),
                                                 NumberOfContracts = 5
                                             });

            db.ModelsMySqlRepository.SaveChanges();
        }
    }
}
