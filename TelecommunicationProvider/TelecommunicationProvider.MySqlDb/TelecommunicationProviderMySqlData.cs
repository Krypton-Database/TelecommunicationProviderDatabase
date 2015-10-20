// <copyright  file="TelecommunicationProviderMySqlData.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MySqlDb
{
    using System;
    using Telerik.OpenAccess;

    public class TelecommunicationProviderMySqlData
    {
        public readonly TelecommunicationProviderMySqlDbContext Context;

        private const string ConnectionString = "server=localhost;database=TelecommunicationProviderDb;uid=root;pwd={0};";     

        public TelecommunicationProviderMySqlData()
        {
            var password = this.MySqlPwdPrompt();
            this.Context = new TelecommunicationProviderMySqlDbContext(string.Format(ConnectionString, password));
            this.ModelsMySqlRepository = new Repository(this.Context);
            this.VerifyDatabase();
        }

        public Repository ModelsMySqlRepository { get; set; }

        private void VerifyDatabase()
        {
            var schemaHandler = this.Context.GetSchemaHandler();
            this.EnsureDB(schemaHandler);
        }

        private void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script;

            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }

        private string MySqlPwdPrompt()
        {
            Console.WriteLine("Attempting to connect to local MySql Server...");
            Console.Write("Please enter your password for 'root' account: ");
            Console.ForegroundColor = Console.BackgroundColor;
            var pwd = Console.ReadLine().Trim();
            Console.ResetColor();

            return pwd;
        }
    }
}
