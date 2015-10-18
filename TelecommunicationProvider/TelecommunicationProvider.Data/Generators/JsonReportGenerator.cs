namespace TelecommunicationProvider.Data.Generators
    {
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using TelecommunicationProvider.Models.SqlServerModels;

    class JsonReportGenerator
        {
        private Package package = new Package();

        public JsonReportGenerator()
            {
            this.Income = 0;
            this.Id = package.Id;
            this.Name = package.Name;
            this.Price = package.Price;
            this.Contracts = package.Contracts;
            }

        public static void generateJsonReport()
            {
                var serializer = new JavaScriptSerializer();
                var objectToSerialize = new JsonReportGenerator();
                decimal? totalIncome = 0;

                for (int i = 0; i < objectToSerialize.Contracts.Count; i += 1)
                {
                    totalIncome += objectToSerialize.Price;
                }
            }

        public int Income { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        }
    }
