using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationProvider.MySqlDb
{
    using TelecommunicationProvider.MySqlDb.Models;

    public class Repository
    {
        private TelecommunicationProviderMySqlDbContext context;

        public Repository(TelecommunicationProviderMySqlDbContext context)
        {
            this.context = context;
        }

        public void Add(ModelsMySql model)
        {
            this.context.Add(model);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
