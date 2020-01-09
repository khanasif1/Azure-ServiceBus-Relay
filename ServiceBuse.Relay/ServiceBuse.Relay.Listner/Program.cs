namespace ProductsServer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Data.SqlClient;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.IO;

    class Program
    {
        // Define the Main() function in the service application.
        static void Main(string[] args)
        {
            //var sh = new ServiceHost(typeof(ProductsService));
            var sh = new ServiceHost(typeof(ClientsService));
            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }
    }
    class ClientsService : IClients
    {


        //// Populate array of products for display on website
        //ProductData[] products =
        //    new[]
        //        {
        //            new ProductData{ Id = "1", Name = "Rock",
        //                             Quantity = "1"},
        //            new ProductData{ Id = "2", Name = "Paper",
        //                             Quantity = "3"},
        //            new ProductData{ Id = "3", Name = "Scissors",
        //                             Quantity = "5"},
        //            new ProductData{ Id = "4", Name = "Well",
        //                             Quantity = "2500"},
        //        };

        //// Display a message in the service console application
        //// when the list of products is retrieved.
        //public IList<ProductData> GetProducts()
        //{
        //    Console.WriteLine("GetProducts called.");
        //    return products;
        //}
        public IList<ClientData> GetClients(ClientData _model)
        {
            //Console.WriteLine("GetProducts called.");
            //return products;
            Console.WriteLine("GetClients called.");
            return GetClientsfromSQL(_model);
        }
        public static List<ClientData> GetClientsfromSQL(ClientData _model)
        {
            List<ClientData> lstResponse = new List<ClientData>();
            using (SqlConnection connection = new SqlConnection(@"Server={dbname}.database.windows.net;Database=relaydb;User Id={Uid};Password={pwd};"))
            {
                string queryString = "select distinct top 5 ClientCode,OrgCode,ClientName,ClientOffice,CountryCode from [dbo].[Client]";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open(); ;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2], reader[3], reader[4]);
                        lstResponse.Add(new ClientData
                        {
                            ClientCode = reader[0].ToString(),
                            OrgCode = reader[1].ToString(),
                            ClientName = reader[2].ToString(),
                            ClientOffice = reader[3].ToString(),
                            CountryCode = reader[4].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return lstResponse;
            }
        }

        public bool FileManager(ClientData _model)
        {
            Console.WriteLine("File Manage Command Received");

           string path = AppDomain.CurrentDomain.BaseDirectory;
            String dir = Path.GetDirectoryName(path);
            dir += @"\data";
            string filename = dir + @"\client_data.json";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir); // inside the if statement
            if (_model.Action.ToUpper().Equals("C"))
            {
                try
                {
                    if (!File.Exists(filename))
                    {
                        Console.WriteLine("File Created");
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(filename))
                        {
                            sw.WriteLine(JsonConvert.SerializeObject(_model));
                        }
                    }
                    else
                    {
                        Console.WriteLine("File Edit");
                        using (StreamWriter sw = File.AppendText(filename))
                        {
                            sw.WriteLine(JsonConvert.SerializeObject(_model));
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }   
            }
            else if (_model.Action.ToUpper().Equals("M"))
            {
                Console.WriteLine("File Move Command Received");
                try
                {
                    File.Move(filename, _model.FileDestination);
                    Console.WriteLine(String.Format("File Moved to {0}",_model.FileDestination));
                }
                catch (IOException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("File Action Completed");
            return true;
        }
    }
}