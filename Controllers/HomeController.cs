using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Curriculum_WebApp.Models;

using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Data.Common;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Datakit;

namespace Curriculum_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IConfiguration config;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Models.permissionsModel.AccessGranted = false;
            Models.permissionsModel.AccessGrantedText = "OK";
            config = configuration;
            DataAccess.configuration = configuration;
            Helper.DecryptAndEncrypt.configuration = configuration;
            Helper.DecryptAndEncrypt.setCryptoFeed();
        }

        public IActionResult Index()
        {
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
