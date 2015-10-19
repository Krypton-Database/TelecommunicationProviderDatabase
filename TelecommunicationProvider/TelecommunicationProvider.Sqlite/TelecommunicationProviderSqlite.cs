namespace TelecommunicationProvider.Sqlite
{
    using System;
    using System.Linq;

    public class TelecommunicationProviderSqlite
    {
        public static void Main()
        {
            var db = new UserContext();

            db.User.Add(new User { PhoneManufacturer = "Sony", PhoneModel = "Xperia Z" });
            db.SaveChanges();

            Console.WriteLine(db.User.Count());
        }
    }
}
