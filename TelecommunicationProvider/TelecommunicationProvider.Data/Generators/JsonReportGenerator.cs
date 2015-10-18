namespace TelecommunicationProvider.Data.Generators
    {
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using TelecommunicationProvider.Models.SqlServerModels;

    class JsonReportGenerator
        {
        public static void generateJson()
            {
                var serializer = new JavaScriptSerializer();
                var package = new Package;
            
                decimal? totalIncome = 0;
                int id = package.Id;
                string name = package.Name;
                decimal? price = package.Price;
                ICollection<Contract> contracts = package.Contracts;
                for (int i = 0; i < contracts.Count; i += 1)
                {
                    totalIncome += price;
                }
            }
        }
    }
