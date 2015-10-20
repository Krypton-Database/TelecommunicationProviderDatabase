// <copyright  file="JsonReportGenerator.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Script.Serialization;

    using Newtonsoft.Json;

    using TelecommunicationProvider.Models.SqlServerModels;

    public class JsonReportGenerator
    {
        private readonly Package package = new Package();
        private const string OutputPath = "../../../../OutputData/JSON/Reports/";

        public JsonReportGenerator()
        public void ExportContracts(List<Contract> contracts, string directory)



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

        public static void ExportJson()
            Console.WriteLine("Generating of json reports initialized.");
            string jsonReport;
            if (!Directory.Exists(directory))
            {
                var jsonObject = new JsonReportGenerator();
                jsonObject.WriteJson(jsonObject.GenerateJson(), jsonObject.Id);
                Directory.CreateDirectory(directory);
            }
            foreach (var item in contracts)
            {
                var itemToJson =
                    new
                        {
                            Id = item.Id,
                            PackageName = item.Package.Name,
                            TelephoneNumber = item.TelephoneNumber.Number,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate
                        };

        public void WriteJson(string jsonAsAString, int id)
        {
            File.WriteAllText(Environment.CurrentDirectory + OutputPath + id + ".json", jsonAsAString);
        }
                jsonReport = JsonConvert.SerializeObject(itemToJson, Formatting.Indented);

        public decimal? GenerateIncome()
        {
            var objectToSerialize = new JsonReportGenerator();
            decimal? totalIncome = 0;

            for (int i = 0; i < objectToSerialize.Contracts.Count; i += 1)
            {
                totalIncome += objectToSerialize.Price;
                File.WriteAllText(directory + '/' + item.Id.ToString() + ".json", jsonReport);
                Console.WriteLine("Generating of json reports completed!");
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
