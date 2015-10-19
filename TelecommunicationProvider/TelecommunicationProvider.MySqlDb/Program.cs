using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationProvider.MySqlDb
{
    using TelecommunicationProvider.MySqlDb.Models;

    public static class Program
    {
        public static void Main()
        {
            var db = new TelecommunicationProviderMySqlData();
            db.ModelsMySqlRepository.Add(new ModelsMySql
                                             {
                                                 FirstName = "ajasdbhsdg",
                                                 Ssn = "ajaa",
                                                 Type = "ahdbs",
                                                 LastName = "jahdbahydb"
                                             });

             db.ModelsMySqlRepository.SaveChanges();
        }
    }
}
