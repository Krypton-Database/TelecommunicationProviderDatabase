// <copyright  file="JsonReportGenerator.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class JsonReportGenerator
    {
        private readonly Package package = new Package();

        public JsonReportGenerator()
        {
            this.Income = 0;
            this.Id = this.package.Id;
            this.Name = this.package.Name;
            this.Price = this.package.Price;
            this.Contracts = this.package.Contracts;
        }

        public int Income { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public ICollection<Contract> Contracts { get; set; }

        public static void WriteJson()
        {
            // TODO: Do that tommorrow (19/10/2015)
            // TRY: File.WriteAllText(Environment.CurrentDirectory + @"\JSON.txt", json);
        }

        public decimal? GenerateIncome()
        {
            var objectToSerialize = new JsonReportGenerator();
            decimal? totalIncome = 0;

            for (int i = 0; i < objectToSerialize.Contracts.Count; i += 1)
            {
                totalIncome += objectToSerialize.Price;
            }

            return totalIncome;
        }

        public string GenerateJson()
        {
            var totalIncome = this.GenerateIncome();
            var jsonPrototype = this.GetJson(totalIncome);
            var serializer = new JavaScriptSerializer();

            string serializedJson = serializer.Serialize(jsonPrototype); // Will the real JSON please stand up, please stand up.

            return serializedJson;
        }

        public Dictionary<string, dynamic> GetJson(decimal? totalIncome)
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
    }
}
