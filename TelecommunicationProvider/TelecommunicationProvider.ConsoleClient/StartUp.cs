namespace TelecommunicationProvider.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Data.Migrations;
    using TelecommunicationProvider.Models;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TelecommunicationDbContext, Configuration>());

            var db = new TelecommunicationDbContext();

            var address = new Address()
                           {
                               Name = "Cvetna Gradina",
                               City = "Sofiq",
                               ZipCode = "1234",
                               Country = "BUlgaria",
                               Number = 4
                           };

            db.Adresses.Add(address);
            db.SaveChanges();
            Console.WriteLine(db.Adresses.Count());
        }
    }
}
