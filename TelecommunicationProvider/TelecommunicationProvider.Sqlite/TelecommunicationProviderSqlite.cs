namespace TelecommunicationProvider.Sqlite
{
    using System;
    using System.Linq;

    public class TelecommunicationProviderSqlite
    {
        public static void Main()
        {
            var db = new TelecommunicationProviderDbContext();
            var differentUsersProvidersNum = new DifferentUserProviders
                                                 {
                                                     NumberOfProviders = 4,
                                                     UserSsn = "123467891236"
                                                 };
            db.DifferentUserProviders.Add(differentUsersProvidersNum);
            db.SaveChanges();

            Console.WriteLine(db.DifferentUserProviders.Count());
        }
    }
}
