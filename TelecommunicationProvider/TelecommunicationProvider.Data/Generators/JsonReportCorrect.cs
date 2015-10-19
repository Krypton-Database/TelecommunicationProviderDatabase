namespace TelecommunicationProvider.Data.Generators
{
    using System.Collections.Generic;
    using System.IO;

    using Newtonsoft.Json;

    using TelecommunicationProvider.Models.SqlServerModels;

    public class JsonReportCorrect
    {
        public void ExportContracts(List<Contract> contracts, string directory)
        {
            string jsonReport;
            if (!Directory.Exists(directory))
            {
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

                jsonReport = JsonConvert.SerializeObject(itemToJson, Formatting.Indented);


                File.WriteAllText(directory + '/' + item.Id.ToString() + ".json", jsonReport);

            }
        }
    }
}
