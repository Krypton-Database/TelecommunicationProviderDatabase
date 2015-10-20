namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TelecommunicationProvider.Models.SqlServerModels;
    using TelecommunicationProvider.MySqlDb;
    using TelecommunicationProvider.MySqlDb.Models;

    public class MySqlManipulator
    {
        public void ImportDataToMySql(List<Contract> monthlyList)
        {
            var db = new TelecommunicationProviderMySqlData();
            List<MonthlyNumberOfContracts> monthyContracts = new List<MonthlyNumberOfContracts>();
            var grouped = monthlyList.GroupBy(x => x.StartDate.Date);
            foreach (var item in grouped)
            {              
                db.ModelsMySqlRepository.Add(new MonthlyNumberOfContracts
                    {
                        Date = item.Key.Date, 
                        NumberOfContracts = item.Count()
                    });
            }

            Console.WriteLine("Importing data to mysql initialized.");
            db.ModelsMySqlRepository.SaveChanges();
            Console.WriteLine("Importing data to mysql completed!");
        }
    }
}
