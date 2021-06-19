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
        public LoginController(IConfiguration configuration)
        {

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
                Models.permissionsModel.AccessGranted = true;
                Models.permissionsModel.AccessGrantedText = "OK";
                return View("../Home/Access");
            }
            else
            {
                Models.permissionsModel.AccessGrantedText = "KO";
                Models.permissionsModel.AccessGranted = false;
                return View("../Home/Index");
            }
        }
    }
}