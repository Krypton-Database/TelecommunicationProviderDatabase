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

        public decimal? generateIncome()
            {
                var objectToSerialize = new JsonReportGenerator();
                decimal? totalIncome = 0;

                for (int i = 0; i < objectToSerialize.Contracts.Count; i += 1)
                {
                    totalIncome += objectToSerialize.Price;
                }

                return totalIncome;
            }

        public string generateJson()
            {
                var totalIncome = generateIncome();
                var jsonPrototype = getJson(totalIncome);
                var serializer = new JavaScriptSerializer();

                string serializedJson = serializer.Serialize(jsonPrototype); //Will the real JSON please stand up, please stand up.

                return serializedJson;
            }

        public Dictionary<string, dynamic> getJson(decimal? totalIncome)
            {
            var json = new Dictionary<string, dynamic>
                {
                    { "product-id", this.Id },
                    { "product-name", this.Name },
                    { "total-contract-quantity", this.Contracts.Count },
                    { "total-income", totalIncome },
                };
            return json;
            }

        public int Income { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        }
    }
