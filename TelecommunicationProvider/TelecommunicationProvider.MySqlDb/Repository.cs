namespace TelecommunicationProvider.MySqlDb
{
    using System;
    using System.Linq;
    using TelecommunicationProvider.MySqlDb.Models;

    public class Repository
    {
        private TelecommunicationProviderMySqlDbContext context;

        public Repository(TelecommunicationProviderMySqlDbContext context)
        {
            this.context = context;
        }

        public void Add(MonthlyNumberOfContracts model)
        {
            this.context.Add(model);
        }

        public IQueryable<MonthlyNumberOfContracts> All()
        {
            return this.context.GetAll<MonthlyNumberOfContracts>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
