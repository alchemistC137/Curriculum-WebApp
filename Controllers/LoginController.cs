using Microsoft.AspNetCore.Mvc;
using Curriculum_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Datakit;
using Microsoft.Extensions.Configuration;

namespace Curriculum_WebApp.Controllers
{
    public class LoginController : Controller
    {
        DataAccess dataAccess = new DataAccess();
        permissionsModel permissionsModel;
        public readonly IConfiguration config;
        public LoginController(IConfiguration configuration)
        {

            // _logger = logger;
            permissionsModel = new permissionsModel();
            permissionsModel.AccessGranted = false;
            Models.permissionsModel.AccessGrantedText = "OK";
            config = configuration;
            DataAccess.configuration = configuration;
            Helper.DecryptAndEncrypt.configuration = configuration;
            Helper.DecryptAndEncrypt.setCryptoFeed();
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult checkCredentials(IFormCollection fc)
        {
            UserModel logedUser = new UserModel();

            logedUser.userName = fc["mail"].ToString();
            logedUser.password = Helper.DecryptAndEncrypt.EncryptStringAES(fc["pass"].ToString());

            bool loginOK = dataAccess.checkCredentials(Helper.TypeConverter.UserModel_To_User(logedUser));

            if (loginOK)
            {
                permissionsModel.AccessGranted = true;
                permissionsModel.AccessGrantedText = "OK";
                return View("../Home/Index");
            }
            else
            {
                permissionsModel.AccessGrantedText = "KO";
                permissionsModel.AccessGranted = false;
                return View("Login");
            }
        }
    }
}