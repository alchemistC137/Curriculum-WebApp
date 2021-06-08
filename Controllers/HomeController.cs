using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Curriculum_WebApp.Models;
using watools_log;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Data.Common;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace Curriculum_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration config;




        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            config = configuration;

        }


        public IActionResult Index()
        {

            #region SQL connection

            // try 
            //             { 
            //                 SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            //                 builder.DataSource = "82.223.121.235"; 
            //                 builder.UserID = "root";            
            //                 builder.Password = "";     
            //                 builder.InitialCatalog = "pruebaBaseDatosMarco";

            //                 using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //                 {
            //                     Console.WriteLine("\nQuery data example:");
            //                     Console.WriteLine("=========================================\n");

            //                     connection.Open();       

            //                     String sql = "SELECT id, collation_name FROM sys.databases";

            //                     using (SqlCommand command = new SqlCommand(sql, connection))
            //                     {
            //                         using (SqlDataReader reader = command.ExecuteReader())
            //                         {
            //                             while (reader.Read())
            //                             {
            //                                 Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
            //                             }
            //                         }
            //                     }                    
            //                 }
            //             }
            //             catch (SqlException e)
            //             {
            //                 Console.WriteLine(e.ToString());
            //             }
            //             Console.WriteLine("\nDone. Press enter.");
            //             Console.ReadLine(); 

            #endregion

            using (MySqlConnection connection = new MySqlConnection(config.GetValue<string>("ConnectionStrings:Default")))
            {

                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tablaPrueba";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string nombre = reader["nombre"].ToString();
                    }
                }
            }

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
