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
using Microsoft.AspNetCore.Http;

namespace Curriculum_WebApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public void checkCredentials(IFormCollection fc)
        {

            UserModel logedUser = new UserModel();
            logedUser.user = fc["mail"].ToString();
            logedUser.pass = fc["pass"].ToString();
        }
    }

}